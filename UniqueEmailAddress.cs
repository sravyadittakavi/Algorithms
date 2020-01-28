using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueEmailAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] emails = new string[] {"test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com"};
            Console.WriteLine(NumUniqueEmails(emails));
            Console.ReadLine();
        }

        public static int NumUniqueEmails(string[] emails)
        {
            List<string> uniqueEmails = new List<string>();
            foreach(var email in emails)
            {
                StringBuilder sbEmail = new StringBuilder();
                bool atTheRate = false;
                bool plus = false;
                foreach(var s in email)
                {
                    if (s == '@') atTheRate = true;
                    if (!atTheRate)
                    {                     
                        if (s == '+')
                        {
                            plus = true;
                        }
                        if (s != '.' && !plus)
                        {
                            sbEmail.Append(s);
                        }
                    }
                    else
                    {
                        sbEmail.Append(s);
                    }
                }
                if(!uniqueEmails.Contains(sbEmail.ToString()))
                {
                    uniqueEmails.Add(sbEmail.ToString());
                }
            }
            return uniqueEmails.Count();
        }
    }
}
