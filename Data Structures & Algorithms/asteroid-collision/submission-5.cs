public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        Stack<int> s = new Stack<int>();
        foreach(var asteroid in asteroids){
            if (s.Count == 0){
                s.Push(asteroid);
                continue;
            }

            if (s.Peek() < 0){
                s.Push(asteroid);
                continue;
            }

            if (asteroid > 0){
                s.Push(asteroid);
                continue;
            }

            while (s.Count > 0 && -asteroid > s.Peek() && s.Peek() > 0){
                s.Pop();
            }

            if (s.Count > 0 && s.Peek() == -asteroid){
                s.Pop();
                continue;
            }


            if (s.Count > 0 && s.Peek() > -asteroid)
                continue;
            
            s.Push(asteroid);
        }
        return s.Reverse().ToArray();
    }
}