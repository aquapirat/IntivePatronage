using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace IntiveDotNet
{
    public class DeepDive
    {
        private IEnumerable<Guid> _currentPathGuids;

        #region Public fields

        /// <summary>
        /// Gets or sets main path to create directories from.
        /// </summary>
        public string MainPath { get; set; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Returns full path of current directory tree.
        /// </summary>
        public string FullPath { get; private set; }

        /// <summary>
        /// Gets current level of directory tree.
        /// </summary>
        public ushort CurrentLevel { get; private set; }
        #endregion

        /// <summary>
        /// Creates nested directories.
        /// </summary>
        /// <param name="level">Level of the "lowest" directory.</param>
        /// <exception cref="ArgumentException">Thrown when level value is too big.</exception>
        public void Create(ushort level)
        {
            if (level > 4)
            {
                throw new ArgumentException("Argument value too big. (Max. 4)", nameof(level));
            } 
            _currentPathGuids = GenerateGuids(level);
            CurrentLevel = level;

            FullPath = Path.Combine(MainPath, String.Join("\\", _currentPathGuids));

            try
            {
                Directory.CreateDirectory(FullPath);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Program has no rights to create directories...");
            }
        }

        /// <summary>
        /// Generates Guids
        /// </summary>
        /// <param name="amount">Amount of Guids</param>
        /// <returns></returns>
        private IEnumerable<Guid> GenerateGuids(ushort amount)
        {
            for (ushort i = 0; i < amount; ++i)
            {
                yield return Guid.NewGuid();
            }
        }
    }
}
