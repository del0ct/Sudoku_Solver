#if ANDROID
using Java.Nio.Channels;
using Microsoft.Maui.Controls.PlatformConfiguration;
#endif

using Locoliz = Sudoku_Solver.Resources.Localisation.String;
namespace Sudoku_Solver
{
    public class ExternalFunction
    {
        private static bool Error_check(int[] tester)
        {
            bool ok = true;
            for (int i = 1; i <= 81; i++)
            {
                if (tester[i] != 0)
                {
                    for (int check = 0; check < 9; check++)
                    {
                        if (tester[i] == tester[(i - 1) / 9 * 9 + 1 + check] && i != (i - 1) / 9 * 9 + 1 + check)
                        {
                            ok = false;
                            break;
                        }
                        if (tester[i] == tester[(i - 1) % 9 + 1 + check * 9] && i != (i - 1) % 9 + 1 + check * 9)
                        {
                            ok = false;
                            break;
                        }
                        if (tester[i] == tester[((i - 1) / 9 - (i - 1) / 9 % 3) * 9 + ((i - 1) % 9 + 1 - (i - 1) % 9 % 3) + check % 3 + check / 3 * 9] && i != check % 3 + check / 3 * 9 + ((i - 1) / 9 - (i - 1) / 9 % 3) * 9 + ((i - 1) % 9 + 1 - (i - 1) % 9 % 3))
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (!ok) break;
                }
                else
                {
                    int count = 9;
                    for (int j = 1; j <= 9; j++)
                    {
                        for (int check = 0; check < 9; check++)
                        {
                            if (j == tester[(i - 1) / 9 * 9 + 1 + check] && i != (i - 1) / 9 * 9 + 1 + check)
                            {
                                count--;
                                break;
                            }
                            if (j == tester[(i - 1) % 9 + 1 + check * 9] && i != (i - 1) % 9 + 1 + check * 9)
                            {
                                count--;
                                break;
                            }
                            if (j == tester[((i - 1) / 9 - (i - 1) / 9 % 3) * 9 + ((i - 1) % 9 + 1 - (i - 1) % 9 % 3) + check % 3 + check / 3 * 9] && i != check % 3 + check / 3 * 9 + ((i - 1) / 9 - (i - 1) / 9 % 3) * 9 + ((i - 1) % 9 + 1 - (i - 1) % 9 % 3))
                            {
                                count--;
                                break;
                            }
                        }
                    }
                    if (count == 0)
                    {
                        ok = false;
                        break;
                    }
                }
            }
            return (!ok);
        }
        public static int[] Solve(int[] str)
        {
            if (Error_check(str))
            {
                Error_Alert();
                return str;
            }
            int[] end = new int[82];
            Array.Copy(str, end, str.Length);
            bool back = false;
            for (int i = 1; i <= 81; i++)  // testing each cell
            {
                if (back) { i -= 2; }
                if (i < 1) { break; }
                if (str[i] != 0) { continue; }
                else
                {
                    int start = 1;
                    if (back)
                    {
                        start = end[i] + 1;
                        {
                            end[i] = 0;
                        }
                    }
                    for (int j = start; j < 10; j++)
                    {
                        bool that = true;
                        end[i] = j;
                        for (int check = 0; check < 9; check++)
                        {
                            if (end[i] == end[(i - 1) / 9 * 9 + 1 + check] && i != (i - 1) / 9 * 9 + 1 + check)
                            {
                                that = false;
                                break;
                            }
                            if (end[i] == end[(i - 1) % 9 + 1 + check * 9] && i != (i - 1) % 9 + 1 + check * 9)
                            {
                                that = false;
                                break;
                            }
                            if (end[i] == end[((i - 1) / 9 - (i - 1) / 9 % 3) * 9 + ((i - 1) % 9 + 1 - (i - 1) % 9 % 3) + check % 3 + check / 3 * 9] && i != check % 3 + check / 3 * 9 + ((i - 1) / 9 - (i - 1) / 9 % 3) * 9 + ((i - 1) % 9 + 1 - (i - 1) % 9 % 3))
                            {
                                that = false;
                                break;
                            }
                        }
                        if (that)
                        {
                            back = false;
                            break;
                        }
                        else if (j == 9)
                        {
                            back = true;
                            end[i] = 0;
                        }
                    }
                }
            }
            return end;
        }
        public static async void Error_Alert()
        {
            await Application.Current.Windows[0].Page.DisplayAlert(Locoliz.error, Locoliz.unsolvable, Locoliz.ok);
        }
    }
}