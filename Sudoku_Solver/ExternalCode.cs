public class ExternalFunction
{
    private bool Error_check(int[] tester)
    {
        return true;
    }
    public int[] Solve(int[] str)
    {
        
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
                        if ((end[i] == end[((i - 1) / 9) * 9 + 1 + check]) && (i != (((i - 1) / 9) * 9 + 1 + check)))
                        {
                            that = false;
                            break;
                        }
                        if ((end[i] == end[((i - 1) % 9) + 1 + check * 9]) && (i != (((i - 1) % 9) + 1 + check * 9)))
                        {
                            that = false;
                            break;
                        }
                        if ((end[i] == end[((((i - 1) / 9) - ((i - 1) / 9) % 3) * 9) + ((((i - 1) % 9) + 1) - ((i - 1) % 9) % 3) + check % 3 + check / 3 * 9]) && (i != check % 3 + check / 3 * 9 + ((((i - 1) / 9) - ((i - 1) / 9) % 3) * 9) + ((((i - 1) % 9) + 1) - ((i - 1) % 9) % 3)))
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
}


