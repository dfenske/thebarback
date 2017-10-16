import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './routes/Home';
import { FetchData } from './routes/FetchData';
import { Counter } from './routes/Counter';
import { Search } from './routes/Search';
import { Surprise } from './routes/Surprise';
import { About } from './routes/About';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/counter' component={ Counter } />
    <Route path='/fetchdata' component={ FetchData } />
    <Route path='/search' component={ Search } />
    <Route path='/surprise' component={ Surprise } />
    <Route path='/about' component={ About } />
</Layout>;
