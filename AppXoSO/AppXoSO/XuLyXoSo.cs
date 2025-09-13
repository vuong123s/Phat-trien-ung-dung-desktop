using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace AppXoSO
{
    public class XuLyXoSo
    {
        private DateTime? ExtractDateFromTitle(string title, DateTime? fallback)
        {
            if (string.IsNullOrWhiteSpace(title)) return fallback;

            var m = Regex.Match(title, @"NGÀY\s+(\d{1,2})/(\d{1,2})", RegexOptions.IgnoreCase);
            if (m.Success)
            {
                int day = int.Parse(m.Groups[1].Value);
                int month = int.Parse(m.Groups[2].Value);
                int year = DateTime.Now.Year;

                var guess = new DateTime(year, month, day);
                if (guess > DateTime.Now) year--;

                return new DateTime(year, month, day);
            }

            return fallback;
        }

        public List<KetQuaXoSo> ParseManyFromDescription(string title, string description, DateTime? pubDate = null)
        {
            var results = new List<KetQuaXoSo>();

            DateTime? ngay = ExtractDateFromTitle(title, pubDate);

            if (string.IsNullOrWhiteSpace(description))
            {
                results.Add(new KetQuaXoSo { Tinh = title ?? "", Ngay = ngay });
                return results;
            }

            string decoded = WebUtility.HtmlDecode(description ?? "");
            decoded = Regex.Replace(decoded, @"<(br|BR)\s*/?>", "\n");
            decoded = Regex.Replace(decoded, @"</p\s*>", "\n", RegexOptions.IgnoreCase);
            decoded = Regex.Replace(decoded, @"<.*?>", string.Empty);
            decoded = decoded.Replace("\r", "");
            while (decoded.Contains("\n\n")) decoded = decoded.Replace("\n\n", "\n");

            var lines = decoded.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(l => l.Trim())
                               .Where(l => !string.IsNullOrWhiteSpace(l))
                               .ToList();

            KetQuaXoSo current = null;
            bool foundHeader = false;

            foreach (var rawLine in lines)
            {
                var line = rawLine.Trim();

                var mHeader = Regex.Match(line, @"^\[(.+?)\]\s*(NGÀY\s+\d{1,2}/\d{1,2})?", RegexOptions.IgnoreCase);
                if (mHeader.Success)
                {
                    if (current != null) results.Add(current);
                    current = new KetQuaXoSo
                    {
                        Tinh = mHeader.Groups[1].Value.Trim(),
                        Ngay = ExtractDateFromTitle(title, ngay)
                    };
                    foundHeader = true;
                    continue;
                }

                if (!foundHeader)
                {
                    if (current == null) current = new KetQuaXoSo { Tinh = title ?? "", Ngay = ngay };
                    foundHeader = true;
                }

                if (line.StartsWith("ĐB:", StringComparison.OrdinalIgnoreCase))
                {
                    current.GiaiDB = SplitPrizeNumbers(line.Substring(3));
                }
                else if (line.StartsWith("1:", StringComparison.OrdinalIgnoreCase))
                {
                    current.Giai1 = SplitPrizeNumbers(line.Substring(2));
                }
                else if (line.StartsWith("2:", StringComparison.OrdinalIgnoreCase))
                {
                    current.Giai2 = SplitPrizeNumbers(line.Substring(2));
                }
                else if (line.StartsWith("3:", StringComparison.OrdinalIgnoreCase))
                {
                    current.Giai3 = SplitPrizeNumbers(line.Substring(2));
                }
                else if (line.StartsWith("4:", StringComparison.OrdinalIgnoreCase))
                {
                    current.Giai4 = SplitPrizeNumbers(line.Substring(2));
                }
                else if (line.StartsWith("5:", StringComparison.OrdinalIgnoreCase))
                {
                    current.Giai5 = SplitPrizeNumbers(line.Substring(2));
                }
                else if (line.StartsWith("6:", StringComparison.OrdinalIgnoreCase))
                {
                    current.Giai6 = SplitPrizeNumbers(line.Substring(2));
                }
                else if (line.StartsWith("7:", StringComparison.OrdinalIgnoreCase))
                {
                    current.Giai7 = SplitPrizeNumbers(line.Substring(2));
                }
            }

            if (current != null) results.Add(current);
            return results;
        }

        private List<string> SplitPrizeNumbers(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return new List<string>();
            var tokens = s.Split(new[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return tokens.Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
        }
    }

    
}
