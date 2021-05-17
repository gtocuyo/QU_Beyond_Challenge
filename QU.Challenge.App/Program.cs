using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QU.Challenge.App.BusinessActions;
using QU.Challenge.App.BusinessObjects;
using QU.Challenge.App.Presentation;
using StructureMap;
using System;
using System.Collections.Generic;

namespace QU.Challenge.App
{

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            #region Using StructureMap...
            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Program));
                    _.WithDefaultConventions();
                });

                config.Populate(services);
            });

            var serviceProvider = container.GetInstance<IServiceProvider>();
            #endregion

            var screenBuilder = serviceProvider.GetService<ILayoutService>();

            try
            {
                var wfService = serviceProvider.GetService<IWordFinder>();
                WordFinder_Entity wf = new WordFinder_Entity();

                int size = screenBuilder.PrintFirstBlock();
                List<String> wordsForMatrix = screenBuilder.PrintSecondBlock(size);
                List<String> wordsForSearch = screenBuilder.PrintThirdBlock();

                wf = wfService.BuildFinder(wordsForMatrix);
                screenBuilder.PrintMatrix(wf.Matrix);

                wf.WordsForSearch = wordsForSearch;
                screenBuilder.PrintWordsForSearch(wf.WordsForSearch);

                FindResult_Response result = wfService.Find(wf);
                screenBuilder.PrintFindings(result);

            }
            catch(Exception err)
            {
                screenBuilder.PrintExceptionMsg(err.Message);
            }

        }
    }
}
