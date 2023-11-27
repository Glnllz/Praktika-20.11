using System.Numerics;

Console.WriteLine("Пишите через пробел!!");
string input = Console.ReadLine();
List<int> nums = new List<int>();
List<string> operations = new List<string>();
int j = 0;
bool order = false;
List<string> inputSplit = new List<string>(input.Split(' '));
int temp;
while (!order)
{
    foreach (string s in inputSplit)
    {
        if (s == "*" || s == "/")
        {
            order = true;
            break;
        }
    }

    for (int i = 0; i < inputSplit.Count - 1; i++)
    {
        if (inputSplit[i] == "*" || inputSplit[i] == "/")
        {
            switch (inputSplit[i])
            {
                case "*":
                    temp = Convert.ToInt32(inputSplit[i - 1]) * Convert.ToInt32(inputSplit[i + 1]);
                    inputSplit.RemoveAt(i - 1);
                    inputSplit.RemoveAt(i);
                    inputSplit.RemoveAt(i - 1);
                    inputSplit.Insert(i - 1, Convert.ToString(temp));
                    i = 0;
                    break;
                case "/":
                    temp = Convert.ToInt32(inputSplit[i - 1]) * Convert.ToInt32(inputSplit[i + 1]);
                    inputSplit.RemoveAt(i - 1);
                    inputSplit.RemoveAt(i + 1);
                    inputSplit.RemoveAt(i);
                    inputSplit.Insert(i, Convert.ToString(temp));
                    i = 0;
                    break;
                default:
                    break;
            }
        }
    }
}
int output = 0;

foreach (string s in inputSplit)
{
    if (s == "+" || s == "-")
    {
        operations.Add(s);
    }
    else
    {
        nums.Add(Convert.ToInt32(s));
    }
}

for (int i = 0; i < nums.Count; i++)
{
    switch (operations[j])
    {
        case "+":
            if (output == 0)
            {
                output += nums[i] + nums[i + 1];
                i++;
            }
            else
            {
                output = output + nums[i];
            }
            j++;
            break;
        case "-":
            if (output == 0)
            {
                output += nums[i] - nums[i + 1];
                i++;
            }
            else
            {
                output = output - nums[i];
            }
            j++;
            break;
        case "*":
            if (output == 0)
            {
                output += nums[i] * nums[i + 1];
                i++;
            }
            else
            {
                output = output * nums[i];
            }
            j++;
            break;
        case "/":
            if (output == 0)
            {
                output += nums[i] / nums[i + 1];
                i++;
            }
            else
            {
                output = output / nums[i];
            }
            j++;
            break;
    }
}

Console.WriteLine(output);