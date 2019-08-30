//-------------------------------------------------------------------------------
// <copyright file="IState.cs" company="Appccelerate">
//   Copyright (c) 2008-2017 Appccelerate
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Appccelerate.StateMachine.Machine
{
    using System;
    using States;

    /// <summary>
    /// Represents a state of the state machine.
    /// </summary>
    /// <typeparam name="TState">The type of the state.</typeparam>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    public interface IStateLogic<TState, TEvent>
        where TState : IComparable
        where TEvent : IComparable
    {
        /// <summary>
        /// Fires the specified event id on this state.
        /// </summary>
        /// <param name="context">The event context.</param>
        /// <returns>The result of the transition.</returns>
        ITransitionResult<TState> Fire(IStateDefinition<TState, TEvent> stateDefinition, ITransitionContext<TState, TEvent> context, ILastActiveStateModifier<TState, TEvent> lastActiveStateModifier);

        void Entry(IStateDefinition<TState, TEvent> stateDefinition, ITransitionContext<TState, TEvent> context);

        void Exit(IStateDefinition<TState, TEvent> stateDefinition, ITransitionContext<TState, TEvent> context, ILastActiveStateModifier<TState, TEvent> lastActiveStateModifier);

        TState EnterByHistory(IStateDefinition<TState, TEvent> stateDefinition, ITransitionContext<TState, TEvent> context, ILastActiveStateModifier<TState, TEvent> lastActiveStateModifier);
    }
}