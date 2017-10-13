import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface ISearchState {
  recipe : string
}

export class Search extends React.Component<RouteComponentProps<{}>, ISearchState> {

  constructor() {
    super();
    this.state = {recipe: "hello"};
  }

  componentWillMount() {
    this.getRecipe(1).then((result) => {
      this.setState({recipe: JSON.stringify(result)});
    });
  }

  private getRecipe(id: number) : Promise<any> {
    return fetch(`/recipe/get/${id}`).then((result) => result.json());
  }

  public render() {
    return (
      <div>
        {this.state.recipe}
      </div >
    );
  }
}