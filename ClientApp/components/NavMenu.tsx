import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
  public render() {
    return (
      <nav>
        <div className="nav-wrapper blue-grey darken-4">
          <a href="#" className="brand-logo"><span className="glyphicon glyphicon-glass"></span>The Barback</a>
          <ul id="nav-mobile" className="right hide-on-med-and-down">
              <li>
              <NavLink to={'/'} exact className="nav-link">
                  <span className='glyphicon glyphicon-glass'></span> Search
                </NavLink>
              </li>
              <li>
              <NavLink to={'/counter'} className='nav-link'>
                  <span className='glyphicon glyphicon-tree-conifer'></span> About the Creators
                </NavLink>
              </li>
              <li>
              <NavLink to={'/fetchdata'} className='nav-link'>
                  <span className='glyphicon glyphicon-pencil'></span> Contribute
                </NavLink>
              </li>
          </ul>
        </div>
      </nav>
    );
  }
}
