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
        public static bool NonPayable()
        {
            Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            return tx.GetReferences().Length == 0;
        }

        // returns the script hash in the invoking message
        public static byte[] MessageSender()
        {
            if(NonPayable())
                return MessageSenderNonPayable();
            else {
                Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
                return tx.GetReferences()[0].ScriptHash;
            }
        }

        // returns the value (of NEO) in the invoking message (multiplied by 10^8)
        public static BigInteger MessageValue()
        {
            return MessageValueNeo();
        }

        // returns the value of NEO in the invoking message (multiplied by 10^8)
        public static BigInteger MessageValueNeo()
        {
            if(NonPayable())
                return 0;
            else {
                Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
                TransactionOutput[] outputs = tx.GetOutputs();
                foreach (TransactionOutput output in outputs)
                    if (output.ScriptHash == ExecutionEngine.ExecutingScriptHash && output.AssetId == NeoAssetId)
                        return output.Value;
                return 0;
            }
        }

        // returns the script hash of the invoking element in a NonPayable function. Expects: Assert(NonPayable())
        public static byte[] MessageSenderNonPayable()
        {
            Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            return tx.GetAttributes()[0].Data;
        }

        // returns the script hash of this contract
        public static byte[] ThisContractHash()
        {
            return ExecutionEngine.ExecutingScriptHash;
        }
    }
}
