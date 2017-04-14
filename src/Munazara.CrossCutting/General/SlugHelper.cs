namespace Munazara.CrossCutting.General
{
    public static class SlugHelper
    {
        public static string CreateSlug(string title)
        {
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            string url = title.ToLower().Trim();
            foreach (char item in chars)
            {
                url = url.Replace(item, '-');
            }

            url = url.Replace('ç', 'c');
            url = url.Replace('ğ', 'g');
            url = url.Replace('ı', 'i');
            url = url.Replace('ö', 'o');
            url = url.Replace('ş', 's');
            url = url.Replace('ü', 'u');

            url = url.Replace(' ', '-');
            return url;
        }
    }
}