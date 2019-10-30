using System;
using System.Collections.Generic;
using com.freeclimb.api;
using com.freeclimb.api.call;

namespace ListCalls {
  class Program  {
    static void Main (string[] args) {
      string freeClimbAccountId = System.Environment.GetEnvironmentVariable("ACCOUNT_ID");
      string freeClimbAccountToken = System.Environment.GetEnvironmentVariable("AUTH_TOKEN");
      FreeClimbClient client = new FreeClimbClient (freeClimbAccountId, freeClimbAccountToken);
      CallList callList = client.getCallsRequester.get ();
      if (callList.getTotalSize > 0) {
        while (callList.getLocalSize < callList.getTotalSize) {
          callList.loadNextPage ();
        }
        LinkedList<IFreeClimbCommon> commonList = callList.export ();
        foreach (IFreeClimbCommon element in commonList) {
          Call call = element as Call;
          Console.WriteLine (call.getCallId);
        }
      }
    }
  }
}