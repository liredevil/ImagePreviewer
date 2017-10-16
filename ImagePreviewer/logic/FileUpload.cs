
using System.IO;
using System.Web;

namespace ImagePreviewer.logic
{
    public class FileUpload
    {
        public static string GetFilename(string filename)
        {
            string translitedFileName = GetTranslit(filename);
            int count = 1;
            

            while (isFileExist(translitedFileName))
            {
                translitedFileName = InsertIndexInFilename(translitedFileName, count);
                count++;
            }

            return translitedFileName;
        }

        private static bool isFileExist(string fileName)
        {
            return File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Product_Images"), fileName));
        }


        public static string InsertIndexInFilename(string filename, int index)
        {
            if (index > 1)
            {
                filename = filename.Remove(filename.LastIndexOf('.') - index.ToString().Length - 1, index.ToString().Length + 1);
            }

            return filename.Insert(filename.LastIndexOf('.'), "_" + index);
        }

        private static string GetTranslit(string text)
        {
            string translitedText = "";
            string[] rus = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й",
                             "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф",
                             "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", " " };

            string[] eng = { "A", "B", "V", "G", "D", "E", "YO", "ZH", "Z", "I", "J",
                             "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F",
                             "H", "C", "CH", "SH", "SHH", null, "Y", null, "JE", "YU", "YA", "_" };

            for (int i = 0; i < text.Length; i++)
            {
                bool flag = false;

                for (int j = 0; j < rus.Length; j++)
                {
                    if (text[i].ToString() == rus[j].ToLower())
                    {
                        translitedText += eng[j].ToLower();
                        flag = true;

                        break;
                    }
                    else if (text[i].ToString() == rus[j])
                    {
                        translitedText += eng[j];
                        flag = true;

                        break;
                    }
                }

                if (!flag)
                {
                    translitedText += text[i];
                }
            }

            return translitedText;
        }
    }
}