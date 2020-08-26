using NBitcoin;

namespace BTCPayServer
{
    public partial class BTCPayNetworkProvider
    {
        public void InitBitcoinvault()
        {
            var nbxplorerNetwork = NBXplorerNetworkProvider.GetFromCryptoCode("BTCV");
            Add(new BTCPayNetwork()
            {
                CryptoCode = nbxplorerNetwork.CryptoCode,
                DisplayName = "Bitcoinvault",
                BlockExplorerLink = NetworkType == NetworkType.Mainnet ? "https://explorer.bitcoinvault.global/tx/{0}/" : "https://explorer.bitcoinvault.global/tx/{0}",
                NBXplorerNetwork = nbxplorerNetwork,
                UriScheme = "bitcoinvault",
                DefaultRateRules = new[]
                {
                    "BTCV_X = BTCV_BTC * BTC_X",
                    "BTCV_BTC = coineal(BTCV_BTC)",
                },
                CryptoImagePath = "imlegacy/btcv.svg",
                //LightningImagePath = "imlegacy/btcv-lightning.svg",
                DefaultSettings = BTCPayDefaultSettings.GetDefaultSettings(NetworkType),
                CoinType = NetworkType == NetworkType.Mainnet ? new KeyPath("0'") : new KeyPath("1'")
            });
        }
    }
}
