using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IntiveDotNet
{
    public class DrownItDown
    {
        private readonly DeepDive _deepDive;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="deepDive">Reference to DeepDive object, since we have to retrieve latest paths.</param>
        public DrownItDown(DeepDive deepDive)
        {
            _deepDive = deepDive;
        }

        /// <summary>
        /// Creates file in given level of folder tree.
        /// </summary>
        /// <param name="fileName">Name of file to be created. Default name is "default".</param>
        /// <param name="level">Level in which file should be created.</param>
        /// <exception cref="ArgumentException">Thrown when the value of "level" is higher than <see cref="DeepDive.CurrentLevel"/> </exception>
        public void Drown(string fileName, ushort level)
        {
            fileName = $"{fileName ?? "default"}.txt";

            if (_deepDive.CurrentLevel == 0)
            {
                throw new ArgumentException("There is no path for the file. Use DeepDive first to create directory tree.");
            }

            if (level > _deepDive.CurrentLevel)
            {
                throw new ArgumentOutOfRangeException(nameof(level), $"Level value shouldn't be higher than {_deepDive.CurrentLevel}.");
            }

            if (File.Exists(_deepDive.FullPath))
            {
                Console.WriteLine("File already exists! You can try different level, or build another directory tree.");
            }

            string actualCutPath = CutPath(_deepDive.FullPath, level, _deepDive.CurrentLevel);

            try
            {
                File.Create(Path.Combine(actualCutPath, fileName));
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Program has no rights to create files.");
            }
        }

        private string CutPath(string path, ushort intendedLevel, ushort actualLevel)
        {

            int levelsToCut = actualLevel - intendedLevel;

            for (int i = 0; i < levelsToCut; ++i)
            {
                path = path.Substring(0, path.LastIndexOf('\\'));
            }

            Console.WriteLine(path);

            return path;
        }
    }
}
