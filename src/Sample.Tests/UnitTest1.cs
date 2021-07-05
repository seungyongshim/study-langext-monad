using System;
using FluentAssertions;
using Xunit;
using LanguageExt;
using static LanguageExt.Prelude;
using LanguageExt.TypeClasses;

namespace Sample.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Nullable()
        {
            int? i = 1;

            i.Should().Be(1);
        }

        [Fact]
        public void NullableMap()
        {
            int? a = 1;

            var b = a.Apply(x => x + 2);

            b.Should().Be(3);
        }

        [Fact]
        public void NullableApply()
        {
            int? a = 1;
            int? b = 2;

            var c = a.Apply(x => x + b);

            c.Should().Be(3);
        }

        [Fact]
        public void NullableBind1()
        {
            int? a = 1;

            var b = a.Bind<int, int>(x => x + 2);

            b.Should().Be(3);
        }

        [Fact]
        public void NullableBind2()
        {
            int? a = 1;
            int? b = 2;

            var q = from x in a
                    from y in b
                    select x + y;

            q.Should().Be(3);
        }

        [Fact]
        public void NullableBind3()
        {
            int? a = 1;
            int? b = null;

            var q = from x in a
                    from y in b
                    select x + y;

            q.Should().Be(null);
        }

        [Fact]
        public void NullablePlus()
        {
            int? a = 1;
            int? b = null;

            var c = a + b;

            c.Should().Be(null);
        }


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
