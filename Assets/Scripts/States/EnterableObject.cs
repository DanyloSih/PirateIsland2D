using System;

namespace PirateIsland.States
{
    public abstract class EnterableObject<TContext> : IEnterableObject<TContext> 
        where TContext : class
    {
        private bool _isEnter;
        private TContext _context;

        public TContext Context { get => _context; }
        public bool IsEnter { get => _isEnter; }

        public void Enter(TContext context)
        {
            if (_isEnter)
                throw new Exception($"This ({GetType().Name}) object is already activated, " +
                    $"in order to be used " +
                    $"again, it must be exited using the {nameof(Exit)} method.");

            if (context == null)
                throw new ArgumentNullException();

            _isEnter = true;
            _context = context;

            OnEnter();
        }

        public void Exit()
        {
            if (!_isEnter)
                throw new Exception("This state is not yet active to be able to exit.");

            _isEnter = false;
            _context = null;
            OnExit();
        }

        protected abstract void OnEnter();

        protected abstract void OnExit();
    }
}