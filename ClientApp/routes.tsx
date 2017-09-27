import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Search } from './components/Search';
import { Surprise } from './components/Surprise';
import { About } from './components/About';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/counter' component={ Counter } />
    <Route path='/fetchdata' component={ FetchData } />
    <Route path='/search' component={ Search } />
    <Route path='/surprise' component={ Surprise } />
    <Route path='/about' component={ About } />
</Layout>;
