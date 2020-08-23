import { INCREMENT, DECREMENT } from './constant';

export function incrementAction() {
  console.log("IncrementAction has been sent");
  return {
    type: INCREMENT,
  };
}

export function decrementAction() {
  return{
    type: DECREMENT,
  };
}
