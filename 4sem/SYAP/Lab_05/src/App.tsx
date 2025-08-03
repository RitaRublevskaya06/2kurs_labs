import React, { useState } from 'react';
import './App.css';

type BtnProps = {
  title: string;
  onClick: () => void;
  disabled: boolean;
};

const Button: React.FC<BtnProps> = ({ title, onClick, disabled }) => {
  return <button onClick={onClick} disabled={disabled}>{title}</button>;
};

const Counter: React.FC = () => {
  const [count, setCount] = useState<number>(0);

  const increaseCount = () => {
    setCount(count + 1);
  };

  const resetCount = () => {
    setCount(0);
  };

  return (
    <div className='counter'>
      <div className="square">
      <h1 className={count === 5 ? 'red' : ''}>{count}</h1>
      <div className="button-container">
      <Button title="inc" onClick={increaseCount} disabled={count === 5} />
      <Button title="reset" onClick={resetCount} disabled={count === 0} />
      </div>
      </div>
    </div>
  );
};

export default Counter;
