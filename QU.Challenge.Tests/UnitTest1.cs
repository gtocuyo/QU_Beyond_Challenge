using QU.Challenge.App.BusinessActions;
using QU.Challenge.App.BusinessObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace QU.Challenge.Tests
{

    public class WordFinderService_Should
    {
        [Fact]
        public void Given_A_Valid_Mock_IEnumerable_of_strings_Build_A_Propper_WordFinder_Entity_Matrix()
        {

            WordFinder_Entity validEntityMock = new WordFinder_Entity {
                Matrix = new char[2, 2] { { 'a', 'b' }, { 'b', 'c' } },
                AllWordsInMatrix = new System.Collections.Generic.List<string> { "ab", "bc", "ab", "bc" },
                WordsForSearch = new string[] { "abc", "qwe", "ab", "ba", "bb", "aab" }
            };

            IEnumerable<string> mockWordStreamForMatrix = new string[] { "ab", "bc" };

            WordFinder wfService = new WordFinder();

            WordFinder_Entity resultWfEntity = wfService.BuildFinder(mockWordStreamForMatrix);

            Assert.Equal(validEntityMock.Matrix, resultWfEntity.Matrix);

        }
    }
}
