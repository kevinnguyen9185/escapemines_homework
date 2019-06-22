using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using Application.InputProcessor.Models;
using Application.SequenceProcessor.Interfaces;
using Application.SequenceProcessor.Models;
using Application.Utilities;

namespace Application.SequenceProcessor
{
    public class SequenceProcessor : IProcessSequence
    {
        private readonly GameSetting _gameSetting;
        private readonly IHandleSequenceMove _handleSequenceMove;
        public SequenceProcessor(GameSetting gameSetting, IHandleSequenceMove handleSequenceMove)
        {
            _gameSetting = gameSetting;
            _handleSequenceMove = handleSequenceMove;
        }
        public IEnumerable<CheckSequenceResult> ProcessGameSequences()
        {
            var initialPosition = _gameSetting.StartingPosition;
            foreach (var sequence in _gameSetting.Sequences)
            {
                var currentDirection = initialPosition.Direction;
                var currentPos = initialPosition.CurrentPosition;
                var checkResult = new CheckSequenceResult {Sequences = sequence, Result = ResultEnum.Danger};
                var continueCheck = true;
                
                //Check if initial position is exit point or mine hit
                var initialMoveStatus = _handleSequenceMove.Check(initialPosition, false);
                if (initialMoveStatus == ResultEnum.Success || initialMoveStatus == ResultEnum.MineHit)
                {
                    checkResult.Result = initialMoveStatus;
                    yield return checkResult;
                    continue;
                }

                //If initial check does not indicate success or mine hit, keep checking
                for (var stepIndex = 0; stepIndex < sequence.Count; stepIndex++)
                {
                    var step = sequence[stepIndex];
                    var nextPosition = _handleSequenceMove.Move(step, currentDirection, currentPos);
                    //Check Move
                    if (step == MoveBehaviorEnum.Move)
                    {
                        var moveStatus = _handleSequenceMove.Check(nextPosition, false);
                        if (moveStatus == ResultEnum.Success || moveStatus == ResultEnum.MineHit)
                        {
                            checkResult.Result = moveStatus;
                            continueCheck = false;
                            yield return checkResult;
                            break;
                            
                        }
                    }
                    //Update current position/status 
                    currentPos = nextPosition.CurrentPosition;
                    currentDirection = nextPosition.Direction;
                }

                if (!continueCheck)
                    continue;
                
                yield return checkResult;
            }
        }
    }
}