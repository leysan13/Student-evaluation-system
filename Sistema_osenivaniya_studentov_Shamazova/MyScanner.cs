using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    class MyScanner
    {
        private StreamReader sr;
        private string[] tokens;
        private int cur;
        private char[] delimiters;

        public MyScanner(StreamReader reader, char[] delim) {
            sr = reader;
            delimiters = delim;
        }

        public MyScanner(StreamReader reader) {
            new MyScanner(reader, new char[] { ' ' });
        }

        public string ReadToken() {
            while (tokens == null || tokens.Length == cur) {
                try {
                    tokens = sr.ReadLine().Split(delimiters);
                    cur = 0;
                } catch (IOException e) {
                    return null;
                }
            }
            return tokens[cur++];
        }

        public int ReadInt() {
            return int.Parse(ReadToken());
        }

        public bool HasNext() {
        while (tokens == null || tokens.Length == cur) {
                string s = sr.ReadLine();
                if (s == null) {
                    return false;
                }
                tokens = s.Split(delimiters);
                cur = 0;
        }
            return true;
        }
    }
}
