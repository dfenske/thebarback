import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class Footer extends React.Component<{}, {}> {
  public render() {
    return (
      <footer className="page-footer blue-grey darken-4">
        <div className="footer-copyright">
          <div className="container">
            © {(new Date()).getFullYear()} Hammie and Penguin
            </div>
        </div>
      </footer>
    );
  }
}