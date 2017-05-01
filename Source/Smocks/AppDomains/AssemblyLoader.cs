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
using System.Reflection;

namespace Smocks.AppDomains
{
    /// <summary>
    /// Responsible for loading assemblies from disk.
    /// </summary>
    [Serializable]
    public class AssemblyLoader : IAssemblyLoader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyLoader"/> class.
        /// </summary>
        /// <param name="path">The path of the <see cref="Assembly"/> to load.</param>
        public AssemblyLoader(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Gets the path of the <see cref="Assembly"/> to load.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Loads the assembly associated with this loader into the current <see cref="AppDomain" />.
        /// </summary>
        /// <returns>
        /// The <see cref="Assembly" /> that was loaded.
        /// </returns>
        public Assembly Load()
        {
            Assembly assembly = null;

            if (!string.IsNullOrEmpty(Path))
            {
                assembly = Assembly.LoadFrom(Path);
            }

            return assembly;
        }
    }
}