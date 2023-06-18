using System;

namespace MefodyLibrary.Classes
{
    public static class InputConverter
    {
        public static CasesEnum GetCase(string sCase)
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

        public static GendersEnum GetGender(string sGender)
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
