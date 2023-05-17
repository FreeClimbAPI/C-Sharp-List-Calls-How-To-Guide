using System;
using System.Collections.Generic;
using freeclimb.Api;
using freeclimb.Client;
using freeclimb.Enums;
using freeclimb.Model;

namespace ListCalls
{
    public class Program
    {
        public static string getFreeClimbAccountId()
        {
            return System.Environment.GetEnvironmentVariable("ACCOUNT_ID");
        }
        public static string getFreeClimbApiKeys()
        {
            return System.Environment.GetEnvironmentVariable("API_KEY");
        }

        public static string getFromNumber()
        {
            return System.Environment.GetEnvironmentVariable("FROM_NUMBER");
        }

        public static string getToNumber()
        {
            return System.Environment.GetEnvironmentVariable("TO_NUMBER");
        }
        static void Main(string[] args)
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.freeclimb.com/apiserver/";
            config.Username = getFreeClimbAccountId();
            config.Password = getFreeClimbApiKeys();
            DefaultApi Api = new DefaultApi(config);

            string to = getToNumber();
            // Use as env variable rather than defining it in the code
            string from = getFromNumber();

            CallList callList = Api.ListCalls(null, to, from, CallStatus.COMPLETED);

            for (int i = 0; i < callList.Calls.Count; i++)
            {
                Console.WriteLine(callList.Calls[i]);
            }

            // CallList callList = client.getCallsRequester.get();
            // if (callList.getTotalSize > 0)
            // {
            //     while (callList.getLocalSize < callList.getTotalSize)
            //     {
            //         callList.loadNextPage();
            //     }
            //     LinkedList<IFreeClimbCommon> commonList = callList.export();
            //     foreach (IFreeClimbCommon element in commonList)
            //     {
            //         Call call = element as Call;
            //         Console.WriteLine(call.getCallId);
            //     }
            // }
        }
    }
}