import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class About extends React.Component<RouteComponentProps<{}>, {}> {
  public render() {
    return (
      <div>
        Here's where we talk about who we are and why we made this site, and our favorite drink
      </div >
    );
  }
}