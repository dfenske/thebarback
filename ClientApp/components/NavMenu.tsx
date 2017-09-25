import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
  public render() {
    return (
      <nav>
        <div className="nav-wrapper blue-grey darken-4">
          <a href="#" className="brand-logo"><i className="large material-icons">local_bar</i>
            The Barback</a>
          <ul id="nav-mobile" className="right hide-on-med-and-down">
            <li title="Search">
              <NavLink to={'/'} exact className="nav-link" >
                <i className="large material-icons">search</i>
              </NavLink>
            </li>
            <li>
              <NavLink to={'/counter'} className='nav-link' title="About">
                <i className="large material-icons">accessibility</i>
              </NavLink>
            </li>
            <li>
              <NavLink to={'/fetchdata'} className='nav-link' title="Contribute">
                <i className="large material-icons">create</i>
              </NavLink>
            </li>
          </ul>
        </div>
      </nav>
    );
  }
}
