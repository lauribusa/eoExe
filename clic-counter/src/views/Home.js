import React from 'react';

function Home({
  onIncrement,
  onDecrement,
  counter,
}) {
  return (
    <div>
      <span>Vous avez cliqué {counter} fois</span>
      <button onClick={onIncrement}>
        Incrémenter
      </button>

      <button onClick={onDecrement}>
        Décrémenter
      </button>
    </div>
  );
};

export default Home;
