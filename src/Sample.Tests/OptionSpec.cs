namespace Sample.Tests
{
    using FluentAssertions;
    using LanguageExt;
    using Xunit;
    using static LanguageExt.Prelude;

    public class OptionSpec
    {
        [Fact]
        public void Option()
        {
            var a = Some(1);

            a.Should<Option<int>>().Be(1);
        }

        [Fact]
        public void OptionMap()
        {
            var a = Some(1);
            var b = a.Map(x => x + 2);

            b.Should<Option<int>>().Be(3);
        }

        [Fact]
        public void OptionBind1()
        {
            var q = from a in Some(1)
                    from b in Some(2)
                    select a + b;

            q.Should<Option<int>>().Be(3);
        }

        [Fact]
        public void OptionBind2()
        {
            Option<int> a = Some(1);
            Option<int> b = None;

            var q = from x in a
                    from y in b
                    select x + y;

            q.Should<Option<int>>().Be(None);
        }

        

    }
}
