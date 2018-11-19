using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Helpers.General;
using TNT.Helpers.Logging;

namespace TNT.Helpers
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                var s = Test.l.ToReadableString();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                var s = GetByDict(Test.l);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public enum Test
        {
            a,
            b,
            c,
            d,
            e,
            f,
            g,
            h,
            i,
            j,
            k,
            l,
            m,
            n,
            o,
            p,
            q,
            r,
            s,
            t,
            u,
            v,
            w,
            x,
            y,
            z,
            a1,
            a2,
            a3,
            a4,
            a5,
            a6,
            a7,
            a8,
            a9,
            a10,
            a11
        }

        public static string ToReadableString(this Test e)
        {
            switch (e)
            {
                case Test.a: return "1";
                case Test.b: return "2";
                case Test.c: return "3";
                case Test.d: return "4";
                case Test.e: return "5";
                case Test.f: return "6";
                case Test.g: return "7";
                case Test.h: return "8";
                case Test.i: return "9";
                case Test.j: return "10";
                case Test.k: return "11";
                case Test.l: return "12";
                case Test.m: return "13";
                case Test.n: return "14";
                case Test.o: return "15";
                case Test.p: return "16";
                case Test.q: return "17";
                case Test.r: return "18";
                case Test.s: return "19";
                case Test.t: return "20";
                case Test.u: return "21";
                case Test.v: return "22";
                case Test.w: return "23";
                case Test.x: return "24";
                case Test.y: return "25";
                case Test.z: return "26";
                case Test.a1: return "27";
                case Test.a2: return "28";
                case Test.a3: return "29";
                case Test.a4: return "30";
                case Test.a5: return "31";
                case Test.a6: return "32";
                case Test.a8: return "33";
                case Test.a9: return "34";
                case Test.a10: return "35";
                case Test.a11: return "36";
            }
            return null;
        }

        public static IDictionary<Test, string> dict = new Dictionary<Test, string>()
        {
                { Test.a,  "1"},
                { Test.b,  "2"},
                { Test.c,  "3"},
                { Test.d,  "4"},
                { Test.e,  "5"},
                { Test.f,  "6"},
                { Test.g,  "7"},
                { Test.h,  "8"},
                { Test.i,  "9"},
                { Test.j,  "10"},
                { Test.k,  "11"},
                { Test.l,  "12"},
                { Test.m,  "13"},
                { Test.n,  "14"},
                { Test.o,  "15"},
                { Test.p,  "16"},
                { Test.q,  "17"},
                { Test.r,  "18"},
                { Test.s,  "19"},
                { Test.t,  "20"},
                { Test.u,  "21"},
                { Test.v,  "22"},
                { Test.w,  "23"},
                { Test.x,  "24"},
                { Test.y,  "25"},
                { Test.z,  "26"},
                { Test.a1,  "27"},
                { Test.a2,  "28"},
                { Test.a3,  "29"},
                { Test.a4,  "30"},
                { Test.a5,  "31"},
                { Test.a6,  "32"},
                { Test.a8,  "33"},
                { Test.a9,  "34"},
                { Test.a10,  "35"},
                { Test.a11,  "36"}
        };

        public static string GetByDict(Test key)
        {
            return dict[key];
        }

    }
}
