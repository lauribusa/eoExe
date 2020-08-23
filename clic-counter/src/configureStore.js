/**
 * Create the store with dynamic reducers
 */

import { createStore, applyMiddleware, compose } from 'redux';
import createSagaMiddleware from 'redux-saga';
import { routerMiddleware } from 'connected-react-router';
import createReducer from './reducers';
import homeContainerReducer from './containers/HomeContainer/reducer';

export default function configureStore(initialState = {}, history) {
  const reduxSagaMonitorOptions = {};

  const sagaMiddleware = createSagaMiddleware(reduxSagaMonitorOptions);

  // In case you want to inject more middleware
  const middlewares = [sagaMiddleware, routerMiddleware(history)];

  const enhancers = [applyMiddleware(...middlewares)];

  /* eslint-disable no-underscore-dangle, indent */
  const composeEnhancers =
    process.env.NODE_ENV !== 'production' &&
    typeof window === 'object' &&
    window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__
      ? window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__({})
      : compose;
  /* eslint-enable */
  const store = createStore(
    createReducer(homeContainerReducer),
    initialState,
    composeEnhancers(...enhancers),
    // eslint-disable-next-line no-underscore-dangle
  );

  // Extensions
  store.runSaga = sagaMiddleware.run;
  store.injectedReducers = {homeContainerReducer}; // Reducer registry
  store.injectedSagas = {}; // Saga registry

  return store;
}
