using System;
try
{
    Console.WriteLine("Enter a name");
    string na = Console.ReadLine();
    Console.WriteLine("Enter the account number");
    int num = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the percentage of the account");
    double per = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Enter the amount available in the account");
    int s = Convert.ToInt32(Console.ReadLine());
    Account1 acc = new Account1(na, num, per, s);
    int n = int.MaxValue;
    string words;
    while (n != 0)
    {
        Console.WriteLine('\n' + "Change the owner-1");
        Console.WriteLine("Withdraw or top up your balance-2");
        Console.WriteLine("To accrue interest-3");
        Console.WriteLine("Convert to dollars-4");
        Console.WriteLine("Convert to Euros-5");
        Console.WriteLine("Withdraw the amount in text form-6");
        Console.WriteLine("Stop working-0" + '\n');
        n = Convert.ToInt32(Console.ReadLine());
        switch (n)
        {
            case 1:
                Console.WriteLine("Enter the name of the new owner");
                na = Console.ReadLine();
                acc.Swap(na);
                acc.Print();
                Console.WriteLine();
                break;
            case 2:
                Console.WriteLine("Top up-1, withdraw-2");
                int oper = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the amount to perform the desired operation");
                int value = Convert.ToInt32(Console.ReadLine());
                acc.Account_operation(oper, value);
                acc.Print();
                Console.WriteLine();
                break;
            case 3:
                acc.Accrue_interest();
                Console.WriteLine();
                break;
            case 4:
                acc.Convert_to_dollars();
                Console.WriteLine();
                break;
            case 5:
                acc.Convert_to_Euros();
                Console.WriteLine();
                break;
            case 6:
                words = acc.Get_words(acc.sum);
                Console.WriteLine(words + "RUB" + '\n');
                break;
        }
    }
}
catch (Exception exp)
{
    Console.WriteLine(exp.Message);
}
interface IAccount
{
    void Swap(string name);
    void Account_operation(int n, int meaning);
    void Accrue_interest();
    void Convert_to_dollars();
    void Convert_to_Euros();
    string Get_words(int z);
    void Print();
}
abstract class Account : IAccount
{
    protected string name;
    protected int number;
    protected double percent;
    public abstract void Swap(string name);
    public abstract void Account_operation(int n, int meaning);
    public abstract void Accrue_interest();
    public abstract void Convert_to_dollars();
    public abstract void Convert_to_Euros();
    public abstract string Get_words(int z);
    public abstract void Print();
}
class Account1 : Account
{
    public int sum;

    public Account1(string name, int number, double percent, int sum)
    {
        this.name = name;
        this.number = number;
        this.percent = percent;
        this.sum = sum;
    }
    public override void Swap(string name)
    {
        this.name = name.ToString();
    }
    public override void Account_operation(int n, int meaning)
    {
        if (n == 1)
        {
            sum += Math.Abs(meaning);
        }
        else
        {
            if (Math.Abs(meaning) < sum)
            {
                sum -= Math.Abs(meaning);
            }
            else
            {
                Console.WriteLine("The amount being debited is more than the amount available in the account");
            }
        }
    }
    public override void Accrue_interest()
    {
        sum = Convert.ToInt32(sum + sum * (percent / 100));
        Console.WriteLine("The amount on the account with interest " + sum);
    }
    public override void Convert_to_dollars()
    {
        Console.WriteLine("Account Holder: " + name + '\n' + "Account number: " + number + '\n' + "Accrued interest: " + percent + "%" + '\n' + "The amount on the account: " + (sum / 92.57) + " USD");
    }
    public override void Convert_to_Euros()
    {
        Console.WriteLine("Account Holder: " + name + '\n' + "Account number: " + number + '\n' + "Accrued interest: " + percent + "%" + '\n' + "The amount on the account: " + (sum / 100.41) + " EUR");
    }
    public override void Print()
    {
        Console.WriteLine('\n' + "Account Holder: " + name + '\n' + "Account number: " + number + '\n' + "Accrued interest: " + percent + "%" + '\n' + "The amount on the account: " + sum + " RUB");
    }
    public override string Get_words(int z)
    {
        string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] teens = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        if (z == 0)
        {
            return "zero";
        }
        string words = "";
        if ((z / 1000) > 0)
        {
            words += Get_words(z / 1000) + " thousand ";
            z %= 1000;
        }
        if ((z / 100) > 0)
        {
            words += ones[z / 100] + " hundred ";
            z %= 100;
        }
        if (z > 0)
        {
            if (words != "")
            {
                words += "and ";
            }
            if (z < 10)
            {
                words += ones[z];
            }
            else if (z < 20)
            {
                words += teens[z - 11];
            }
            else
            {
                words += tens[z / 10];
                if ((z % 10) > 0)
                {
                    words += "-" + ones[z % 10];
                }
            }
        }
        return words;
    }
}