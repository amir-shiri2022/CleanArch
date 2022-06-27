using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Shared.Abstractions.Domain
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public int Version { get; protected set; }
        private bool _versionIncremented;

        public IEnumerable<IDomainEvent> Events => _events;
        private readonly List<IDomainEvent> _events = new();
        protected void AddEvents(IDomainEvent @event)
        {
            if (_events.Any() && !_versionIncremented)
            {
                Version++;
                _versionIncremented = true;
                _events.Add(@event);
            }
        }
        protected void ClearEvents() => _events.Clear();
        protected void Incremented()
        {
            if (_versionIncremented)
                return;
            Version++;
            _versionIncremented = true;
        }
    }
}
