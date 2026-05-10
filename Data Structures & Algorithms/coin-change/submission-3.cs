public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if (amount == 0) return 0;

        int[] amounts = new int[amount+1];
        amounts[0] = 0;

        for (int i = 1; i < amounts.Length; i++){
            amounts[i] = -1;
            for (int idx = 0; idx < coins.Length; idx++){
                int withoutTheCoin = i - coins[idx];
                if (withoutTheCoin >= 0 && amounts[withoutTheCoin] != -1){
                    amounts[i] = amounts[i] == -1 ? amounts[withoutTheCoin]+1 : Math.Min(amounts[withoutTheCoin]+1, amounts[i]);
                }
            }
        }

        return amounts[amount];
    }
}
