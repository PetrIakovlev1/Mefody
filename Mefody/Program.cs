using System;

namespace Mefody
{
    class Program
    {
        private static NumberAnalyzer analyzer = new NumberAnalyzer();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Преобразование целого числа в строку прописью, в любом падеже и в любом роде\n");
            sumProp(31, "М", "Р");
            sumProp(22, "Ж", "Д");
            sumProp(154323, "М", "И");
            sumProp(154323, "М", "Т");
            

            sumPropAll(-1);

            Console.ReadLine();
        }

        static void sumProp(long nSum, string sGender, string sCase)
        {
            Console.Write($"{nSum}, '{sGender}', '{sCase}' - ");
            Console.WriteLine(analyzer.ToString(nSum, GetCase(sCase), GetGender(sGender)));
        }

        static void sumPropAll(long nSum)
        {
            Console.WriteLine(new String('#', 50));
            foreach (CasesEnum cs in (CasesEnum[])Enum.GetValues(typeof(CasesEnum)))
            {
                foreach (GendersEnum gr in (GendersEnum[])Enum.GetValues(typeof(GendersEnum)) )
                {
                    Console.Write($"{nSum}, '{cs}', '{gr}' - ");
                    Console.WriteLine(analyzer.ToString(nSum, cs, gr));
                }
            }
        }

        static CasesEnum GetCase(string sCase)
        {
            CasesEnum casesEnum = new CasesEnum();
            casesEnum = CasesEnum.Nominative;

            if (!string.IsNullOrWhiteSpace(sCase))
            {
                if (string.Equals(sCase, "Р", StringComparison.InvariantCultureIgnoreCase))
                    casesEnum = CasesEnum.Genitive;
                else if (string.Equals(sCase, "Д", StringComparison.InvariantCultureIgnoreCase))
                    casesEnum = CasesEnum.Dative;
                else if (string.Equals(sCase, "В", StringComparison.InvariantCultureIgnoreCase))
                    casesEnum = CasesEnum.Accusative;
                else if (string.Equals(sCase, "Т", StringComparison.InvariantCultureIgnoreCase))
                    casesEnum = CasesEnum.Instrumental;
                else if (string.Equals(sCase, "П", StringComparison.InvariantCultureIgnoreCase))
                    casesEnum = CasesEnum.Prepositional;
            }

            return casesEnum;
        }

        static GendersEnum GetGender(string sGender)
        {
            GendersEnum gendersEnum = new GendersEnum();
            gendersEnum = GendersEnum.Undefined;

            if (!string.IsNullOrWhiteSpace(sGender))
            {
                if (string.Equals(sGender, "М", StringComparison.InvariantCultureIgnoreCase))
                    gendersEnum = GendersEnum.Masculine;
                else if (string.Equals(sGender, "Ж", StringComparison.InvariantCultureIgnoreCase))
                    gendersEnum = GendersEnum.Feminine;
                else if (string.Equals(sGender, "С", StringComparison.InvariantCultureIgnoreCase))
                    gendersEnum = GendersEnum.Neuter;
            }

            return gendersEnum;
        }
    }
}
