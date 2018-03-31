using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;

namespace NeoFrame
{
    public class Utils
    {
        // NEO asset id. the hash is in reversed order, for use in internal functions.
        private static readonly byte[] NeoAssetId = { 155, 124, 255, 218, 166, 116, 190, 174, 15, 147, 14, 190, 96, 133, 175, 144, 147, 229, 254, 86, 179, 74, 92, 34, 12, 205, 207, 110, 252, 51, 111, 197 };

        // tests if boolean is true, otherwise throws exception (ExecutionEngine will FAIL)
        public static void Assert(bool b)
        {
            if(!b)
                throw new Exception();
        }

        // checks if no assets are being sent with the message (testing only NEO asset for now)
        public static bool isNonPayable()
        {
            return false;
        }

        // returns the script hash of the invoking element
        public static byte[] MessageSender()
        {
                        Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            return tx.GetAttributes()[0].Data;
        }

        // returns the script hash of the invoking element in a NonPayable function. Expects: Assert(isNonPayable())
        public static byte[] MessageSenderNonPayable()
        {
            Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            return tx.GetAttributes()[0].Data;
        }

    }

}
