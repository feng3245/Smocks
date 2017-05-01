﻿#region License
//// The MIT License (MIT)
//// 
//// Copyright (c) 2015 Tom van der Kleij
//// 
//// Permission is hereby granted, free of charge, to any person obtaining a copy of
//// this software and associated documentation files (the "Software"), to deal in
//// the Software without restriction, including without limitation the rights to
//// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
//// the Software, and to permit persons to whom the Software is furnished to do so,
//// subject to the following conditions:
//// 
//// The above copyright notice and this permission notice shall be included in all
//// copies or substantial portions of the Software.
//// 
//// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using Smocks.Setups;
using Smocks.Tests.TestUtility;

namespace Smocks.Tests.Setups
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class SetupTargetCollectionTests
    {
        [TestCase]
        public void Constructor_TargetsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new RewriteTargetCollection(null));
            Assert.AreEqual("targets", exception.ParamName);
        }

        [TestCase]
        public void GetMatcher_ReturnsMatcherForProvidedTargets()
        {
            var targets = new[]
            {
                TestDataFactory.CreateSetupTarget(() => Console.WriteLine()),
                TestDataFactory.CreateSetupTarget(() => Console.ReadLine())
            };

            var subject = new RewriteTargetCollection(targets);
            var matcher = subject.GetMatcher(TestDataFactory.CreateModuleDefinition());

            var result0 = matcher.GetMatchingTargets(CecilUtility.Import(targets[0].Methods[0]));
            var result1 = matcher.GetMatchingTargets(CecilUtility.Import(targets[1].Methods[0]));

            Assert.AreEqual(targets[0], result0.Single());
            Assert.AreEqual(targets[1], result1.Single());
        }
    }
}