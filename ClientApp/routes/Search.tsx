import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { IRecipe } from '../models/index';
import { Recipe } from '../components/Recipe';

interface ISearchState {
  recipe?: IRecipe,
  recipeId?: number,
}

export class Search extends React.Component<RouteComponentProps<{}>, ISearchState> {
  changeRecipe(): any {
    if (this.state.recipeId === 0) {
      this.getRecipe(1);
    } else {
      this.getRecipe(0);
    }
  }

  constructor() {
    super();
    this.state = {};
  }

  componentWillMount() {
    this.getRecipe(1);
  }

  private getRecipe(id: number): void {
    fetch(`/recipe/get/${id}`).then((result) => result.json()).then((result) => {
      this.setState({ recipe: result, recipeId: id });
    });
  }

  public render() {
    if (this.state.recipe) {
      return (
        <div>
          <a className="waves-effect waves-light btn" onClick={this.changeRecipe.bind(this)}>Switch recipe</a>
          <Recipe recipe={this.state.recipe} />
        </div>
      );
    }
    return null;
  }
}