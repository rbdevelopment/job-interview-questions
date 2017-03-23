using System.Collections.Generic;
using NSubstitute;
using Xunit;

namespace Patterns
{
    public class ObserverPattern
    {
        public interface IObserve
        {
            void StateChanged(int state);
        }

        private class Target
        {
            private readonly List<IObserve> _observers = new List<IObserve>();

            public void ChangeState(int state)
            {
                // Do something with the new state
                // and notify all the observers.
                NotifyObservers(state);
            }

            private void NotifyObservers(int state)
            {
                foreach (var observer in _observers)
                    observer.StateChanged(state);
            }

            public void AttachObserver(IObserve observer)
            {
                if (!_observers.Contains(observer))
                    _observers.Add(observer);
            }

            public void DettachObserver(IObserve observer)
            {
                if (_observers.Contains(observer))
                    _observers.Remove(observer);
            }
        }

        [Fact]
        public void ObserversAreNotifiedWhenStateChanges()
        {
            var observer1 = Substitute.For<IObserve>();
            var observer2 = Substitute.For<IObserve>();

            var target = new Target();
            target.AttachObserver(observer1);
            target.AttachObserver(observer2);
            target.ChangeState(1);

            observer1.Received(1).StateChanged(1);
            observer2.Received(1).StateChanged(1);

            target.DettachObserver(observer2);
            observer2.ClearReceivedCalls();

            target.ChangeState(2);

            observer1.Received(1).StateChanged(2);
            observer2.DidNotReceive().StateChanged(Arg.Any<int>());
        }
    }
}