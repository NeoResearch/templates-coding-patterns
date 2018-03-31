namespace Neo.SmartContract
{
    public class NeoFrame_Test : Framework.SmartContract
    {
        public static void Testing()
        {
            Runtime.Notify("Sender:");
            Runtime.Notify(NeoFrame.Utils.MessageSender());
            Runtime.Notify("Value:");
            Runtime.Notify(NeoFrame.Utils.MessageValue());
            Runtime.Notify("Contract:");
            Runtime.Notify(NeoFrame.Utils.ThisContractHash());
        }
    }
}
