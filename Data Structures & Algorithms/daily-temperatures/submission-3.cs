public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var stack = new Stack<int>();
        var result = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; i++){
            var currentTemp = temperatures[i];

            while (stack.Count() > 0 && currentTemp > temperatures[stack.Peek()]){
                int idx = stack.Pop();
                result[idx] = i - idx;
            }

            stack.Push(i);
        }

        return result;
    }
}
