using System;
using Application.InputProcessor;
using Application.InputProcessor.Interfaces;
using Application.SequenceProcessor;
using Application.SequenceProcessor.Interfaces;
using Application.Utilities;

namespace MainProgram
{
    /// <summary>
    /// This is main program
    /// </summary>
    internal static class Program
    {
        private static IImportSource _importSource;
        private static IInputBuilder _builder;
        private static IProcessSequence _processSequence;
        private static IHandleSequenceMove _handleSequenceMove;
        
        private static void Main(string[] args)
        {
            var textFilePath = args[0];
            
            RegisterInstance(textFilePath);

            var results = _processSequence.ProcessGameSequences();

            foreach (var result in results)
            {
                Console.WriteLine($"{result.Result.ToString()} - {result.Sequences.ToSequenceString()}");
            }
        }

        private static void RegisterInstance(string filePath)
        {
            _importSource = new ImportFileSource();
            
            _builder = new InputBuilder(_importSource);
            
            var gameSetting =
                _builder
                    .ReadText(filePath)
                    .ReadBoardSize()
                    .ReadExitPoint()
                    .ReadMinePosition()
                    .ReadStartingPosition()
                    .ReadSequences()
                    .Build();

            _handleSequenceMove = new SequenceMoveHandler(gameSetting);
            
            _processSequence = new SequenceProcessor(gameSetting, _handleSequenceMove);
        }
    }
}