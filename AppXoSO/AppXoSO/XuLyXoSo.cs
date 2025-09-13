using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace AppXoSO
{
    public class XuLyXoSo
    {
        private DateTime? TachNgay(string title, DateTime? fallback)
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

        public List<KetQuaXoSo> TachDescription(string title, string description, DateTime? pubDate = null)
        {
            var results = new List<KetQuaXoSo>();

            DateTime? ngay = TachNgay(title, pubDate);

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
                        Ngay = TachNgay(title, ngay)
                    };
                    foundHeader = true;
                    continue;
                }

                if (!foundHeader)
                {
                    if (current == null) current = new KetQuaXoSo { Tinh = title ?? "", Ngay = ngay };
                    foundHeader = true;
                }

                if (line.StartsWith("ĐB:"))
                {
                    current.GiaiDB = ChiaSoGiai(line.Substring(3));
                }
                else if (line.StartsWith("1:"))
                {
                    current.Giai1 = ChiaSoGiai(line.Substring(2));
                }
                else if (line.StartsWith("2:"))
                {
                    current.Giai2 = ChiaSoGiai(line.Substring(2));
                }
                else if (line.StartsWith("3:"))
                {
                    current.Giai3 = ChiaSoGiai(line.Substring(2));
                }
                else if (line.StartsWith("4:"))
                {
                    current.Giai4 = ChiaSoGiai(line.Substring(2));
                }
                else if (line.StartsWith("5:"))
                {
                    current.Giai5 = ChiaSoGiai(line.Substring(2));
                }
                else if (line.StartsWith("6:"))
                {
                    current.Giai6 = ChiaSoGiai(line.Substring(2));
                }
                else if (line.StartsWith("7:"))
                {
                    current.Giai7 = ChiaSoGiai(line.Substring(2));
                }
            }

            if (current != null) results.Add(current);
            return results;
        }

        private List<string> ChiaSoGiai(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return new List<string>();
            var tokens = s.Split(new[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return tokens.Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
        }
    }

    
}
