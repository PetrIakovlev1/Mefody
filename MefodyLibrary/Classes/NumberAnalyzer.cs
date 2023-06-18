using System;
using System.Text;

namespace MefodyLibrary
{
    public partial class NumberAnalyzer
    {
        /// <summary>
        /// Максимально большое число для написания прописью.
        /// </summary>
        public const long MaxValue = 999999999999;   

        /// <summary>
        /// Склоняет число прописью в указнный падеж и род.
        /// Выбрасывает <see cref="ArgumentOutOfRangeException"/>, если значение больше максимально допустимого <see cref="MaxValue"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="case"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public string ToString(long value, CasesEnum @case, GendersEnum gender)
        {
            if (value > MaxValue)
            {
                throw new ArgumentOutOfRangeException($"The maximum value is {MaxValue}.");
            }

            Strings s = new Strings(@case, gender);

            if (value == 0)
            {
                return s.Zero;
            }

            StringBuilder r = new StringBuilder();
            long v;

            if (value < 0)
            {
                r.Append("минус ");
                value = Math.Abs(value);
            }

            v = value / 1000000000;

            if (v > 0)
            {
                r.Append(this.ToString(v, @case, GendersEnum.Masculine)).Append(" ").Append(this.Case(v, s.Billion[0], s.Billion[1], s.Billion[2])).Append(" ");
                value = value - 1000000000 * v;
            }

            v = value / 1000000;

            if (v > 0)
            {
                r.Append(this.ToString(v, @case, GendersEnum.Masculine)).Append(" ").Append(this.Case(v, s.Million[0], s.Million[1], s.Million[2])).Append(" ");
                value = value - 1000000 * v;
            }

            v = value / 1000;

            if (v > 0)
            {
                r.Append(this.ToString(v, @case, GendersEnum.Feminine)).Append(" ").Append(this.Case(v, s.Thousand[0], s.Thousand[1], s.Thousand[2])).Append(" ");
                value = value - 1000 * v;
            }

            v = value / 100;

            if (v > 0)
            {
                r.Append(s.Hundreds[v - 1]).Append(" ");
                value = value - 100 * v;
            }

            if (value >= 20 || value == 10)
            {
                v = value / 10;
                r.Append(s.Tens[v - 1]).Append(" ");
                value = value - v * 10;
            }

            if (value > 0)
            {
                r.Append(s.Numbers[value - 1]);
            }

            return r.ToString().Trim(' ');
        }

        /// <summary>
        /// Выбирает правильный вариант слова в зависимости от указанного числа.
        /// </summary>
        /// <param name="value">Число для выбора правильного варианта слова.</param>
        /// <param name="one">Вариант слова для употребления с числительным один.</param>
        /// <param name="two">Вариант слова для употребления с числительными два, три, четыре.</param>
        /// <param name="five">Вариант слова для употребления с числительными больше четырех.</param>
        /// <returns></returns>
        public string Case(long value, string one, string two, string five)
        {
            long t = (value % 100 > 20) ? value % 10 : value % 20;

            switch (t)
            {
                case 1:
                    return one;
                case 2:
                case 3:
                case 4:
                    return two;
                default:
                    return five;
            }
        }
    }
}
