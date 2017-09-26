import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Surprise extends React.Component<RouteComponentProps<{}>, {}> {
  public render() {
    return (
      <div>
        Surprise! There's nothing here...
      </div >
    );
  }
}