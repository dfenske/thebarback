import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface ITag {
  name: string,
}

interface IIngredient {
  ingredientName: string,
  amount: string,
  measurement: string,
}

interface IRecipe {
  name: string,
  description: string,
  preparation: string,
  drinkware: string,
  service: string,
  ingredients: Array<IIngredient>,
  garnishes: Array<IIngredient>,
  tags: Array<ITag>,
  imageUrl: string,
}

interface IRecipeProps {
  recipe: IRecipe
}

class Recipe extends React.Component<IRecipeProps, {}> {
  public render() {
    let { name, description, preparation, drinkware, service, ingredients, garnishes, tags, imageUrl } = this.props.recipe;
    return (
      <div className="container center">
      <h2>{name}</h2>
      <h3>{description}</h3>
      <img src={imageUrl} className="card-image"/>
      <div className="recipe row">
          <div className="col s4">
            <div className="ingredients left-align">
              {ingredients.map((ingredient, index) => {
                  return (
                    <div className="row" key={`${ingredient.ingredientName}` + index}>
                      <div className="col s6">
                        {ingredient.amount} {ingredient.measurement}
                      </div>
                      <div className="col s6">
                        {ingredient.ingredientName}
                      </div>
                    </div>);
              })}
              </div>
        </div>
        <div className="col s6 offset-s2 directions left-align">
          <h4>Directions: </h4>
          <div>
            {preparation}
          </div>
          {drinkware &&
              <div>
                Glass: {drinkware}
              </div>
            }
          {service &&
              <div>
                Serve: {service}
              </div>
            }
          {garnishes &&
              <div>
                Garnish: {garnishes.map((g, index) => {
                  return (<span key={`${g} ${index}`}>{g.ingredientName}</span>);
                })}
              </div>
            }
          {tags &&
            <div>
              Tags: {tags.map((t) => { return t.name; }).join(", ")}
            </div>
          }
          </div>
        </div>
      </div>
    );
  }
}

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