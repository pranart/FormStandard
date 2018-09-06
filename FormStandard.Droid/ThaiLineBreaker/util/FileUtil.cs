using System;
using System.Collections.Generic;
using System.Diagnostics;
using Java.IO;
using Java.Lang;
using Java.Nio.Channels;
using Java.Nio.Charset;
using Java.Util;

namespace FormStandard.Shared.ThaiLineBreaker.util
{
    public class FileUtil
    {

        public static Charset utf8 = Charset.ForName("UTF-8");
        public static Charset ms874 = Charset.ForName("x-windows-874");

        public static string ReadPlainText(File f, Charset c)
        {
            ValidateInputFile(f, c);
            FileInputStream stream = null;
            try
            {
                stream = new FileInputStream(f);
                byte[] inn = new byte[(int)f.Length()];
                stream.Read(inn);
                int offset = GetOffset(inn);
                var ans = new Java.Lang.String(inn, offset, inn.Length - offset, c);
                return ans.ReplaceAll("(\\r\\n)|(\\u0085)|(\\u2028)|(\\u2029)|(\\r\\n{0})", "\n");

            }
            catch (Java.Lang.Exception e)
            {
                throw new IOException(e);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        public static string ReadPlainText(InputStream iss, Charset c)
        {
            if (iss == null || c == null)
                throw new NullPointerException();
            try
            {
                byte[] inn = new byte[iss.Available()];
                iss.Read(inn);
                int offset = GetOffset(inn);
                var ans = new Java.Lang.String(inn, offset, inn.Length - offset, c);
                return ans.ReplaceAll(
                    "(\\r\\n)|(\\u0085)|(\\u2028)|(\\u2029)|(\\r\\n{0})", "\n");

            }
            catch (Java.Lang.Exception e)
            {
                throw new IOException(e);
            }
            finally
            {
                iss.Close();
            }
        }

        private static int GetOffset(byte[] inn)
        {
            if (inn.Length < 3)
                return 0;
            // case UTF-8 in Windows
            if (inn[0] == 0xEF && inn[1] == 0xBB && inn[2] == 0xBF)
                return 3;
            if (inn[0] == 0xFE && inn[1] == 0xFF)
                return 2;
            if (inn[0] == 0xFF && inn[1] == 0xFE)
                return 2;
            return 0;
        }

        public static Charset GetSuggestedCharsetIfAny(File f)
        {
            if (!f.CanRead())
                throw new IllegalStateException("File " + f + " can't be read.");
            FileInputStream stream = new FileInputStream(f);
            byte[] inn = new byte[3];
            try
            {
                stream.Read(inn);
                if (inn[0] == 0xEF && inn[1] == 0xBB && inn[2] == 0xBF)
                    return Charset.ForName("UTF-8");
                if (inn[0] == 0xFE && inn[1] == 0xFF)
                    return Charset.ForName("UTF-16BE");
                if (inn[0] == 0xFF && inn[1] == 0xFE)
                    return Charset.ForName("UTF-16LE");
                return null;
            }
            finally
            {
                stream.Close();
            }
        }

        private static void ValidateInputFile(File f, Charset c)
        {
            if (f == null || c == null)
                throw new NullPointerException();
            if (!f.CanRead())
                throw new IllegalStateException("File " + f + " can't be read.");
        }

        private static OutputStreamWriter CreateWriter(File f, Charset c)
        {
            try
            {
                FileOutputStream stream = new FileOutputStream(f);
                OutputStreamWriter ans = new OutputStreamWriter(stream, c);
                return ans;
            }
            catch (FileNotFoundException e)
            {
                e.PrintStackTrace();
                throw new IllegalStateException();// never happen since the input is
                                                  // already validated
            }
        }

        /**
         * This method does 2 things. 1. Add \r in front of every \n in the given
         * string in case it's not present. 2. Write processed string to File with
         * given CharacterSet
         * 
         * @param f
         * @param s
         * @param c
         * @throws IOException
         */
        public static void WritePlainText(File f, string s, Charset c)
        {
            if (f == null || s == null || c == null)
                throw new NullPointerException();
            string postProcess = s.Replace("\\r*\\n", "\r\n");
            OutputStreamWriter writer = null;
            try
            {
                writer = CreateWriter(f, c);
                writer.Write(postProcess);
                writer.Close();
            }
            catch (Java.Lang.Exception e)
            {
                throw new IOException(e);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }

        }

        public static byte[] ReadBinary(File f)
        {
            if (f == null)
                throw new NullPointerException();
            if (!f.CanRead())
                throw new IOException("File can't be read");
            if (f.Length() > 1000000000)
                throw new IOException("File can't be larger than 1GB.");
            FileInputStream fis = null;
            try
            {
                fis = new FileInputStream(f);
                byte[] ans = new byte[(int)f.Length()];
                fis.Read(ans);
                return ans;
            }
            catch (Java.Lang.Exception e)
            {
                throw new IOException(e);
            }
            finally
            {
                if (fis != null)
                    fis.Close();
            }
        }

        public static void printAvailableCharset()
        {

            IDictionary<string, Charset> m = Charset.AvailableCharsets();
            ICollection<string> s = m.Keys;

            foreach (var each in s)
            {
                Debug.WriteLine(m[each]);
            }
        }

        public static void CopyFile(File source, File destination)
        {
            if (destination.Exists())
                destination.CreateNewFile();

            FileChannel inn = new FileInputStream(source).Channel;
            FileChannel outt = new FileOutputStream(destination).Channel;

            if (inn != null && outt != null)
            {
                try
                {
                    inn.TransferTo(0, inn.Size(), outt);
                }
                finally
                {
                    inn.Close();
                    outt.Close();
                }
            }
            else if (inn == null)
            {
                outt.Close();
            }
            else
            {
                inn.Close();
            }
        }

        public static void CopyDirectory(
            File source, File destination,
            bool andAllItsSubdirectories)
        {
            File[] allFiles = source.ListFiles();
            foreach (File f in allFiles)
            {
                if (f.IsDirectory && andAllItsSubdirectories)
                    CopyDirectory(f, new File(destination, f.Name),
                        andAllItsSubdirectories);
                else if (f.IsFile)
                    CopyFile(f, new File(destination, f.Name));
            }
        }
    }
}
