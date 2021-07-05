namespace Sample.Tests
{
    using FluentAssertions;
    using LanguageExt;
    using Xunit;
    using static Interop.FSharp.Functions;


    public class EitherSpec
    {
        [Fact]
        public void Bind1()
        {
            Either<string, int> a = hello("World");
            Either<string, int> b = 3;

            var q = from x in a
                    from y in b
                    select x + y;

            q.Should<Either<string, int>>().Be("Hello World");
        }

        [Fact]
        public void Bind2()
        {
            Either<string, int> a = 2;
            Either<string, int> b = 3;

            var q = from x in a
                    from y in b
                    select x + y;

            q.Should<Either<string, int>>().Be(5);
        }
    }
}
