namespace MathTools;

public partial class Algebra
{
    /// <summary>
    /// オイラー関数の値を求める．
    /// 例: dotnet run algebra euler --showDetails 34
    /// </summary>
    /// <param name="n"></param>
    /// <param name="showDetails"></param>
    [Command("euler", "オイラー関数の値を求めます．例: `algebra euler --showDetails 34`")]
    public void EulersTotientFunction([Option(0)]int n, [Option("d")] bool showDetails)
    {
        if (n < 1)
        {
            Console.Error.WriteLine("1以上の整数を指定してください");
            return;
        }

        var relativelyPrimeNumbers = new ConcurrentBag<int>();

        relativelyPrimeNumbers.Add(1);

        Parallel.ForEach(Enumerable.Range(2, n - 1), x =>
        {
            if (IsRelativelyPrime(x, n)) relativelyPrimeNumbers.Add(x);
        });

        Console.WriteLine($"φ(n) = {relativelyPrimeNumbers.Count}");
        if (showDetails)
        {
            Console.WriteLine($"{n} と互いに素な 1 以上 {n} 以下の整数: {string.Join(", ", relativelyPrimeNumbers.OrderBy(x => x))}");
        }
    }

    /// <summary>
    /// 最大公約数をユークリッドの互除法により求める．
    /// </summary>
    /// <returns></returns>
    private int CalcGreatestCommonDivisor(int m, int n)
    {
        if (n == 0) return m;
        return CalcGreatestCommonDivisor(n, m % n);
    }

    /// <summary>
    /// 2つの整数が互いに素であるかを調べる．
    /// </summary>
    private bool IsRelativelyPrime(int x, int y)
    {
        return CalcGreatestCommonDivisor(x, y) == 1;
    }
}
