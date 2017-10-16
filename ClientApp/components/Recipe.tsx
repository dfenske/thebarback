import * as React from 'react';
import { ITag, IIngredient, IRecipe, IRecipeProps } from '../models/index';

export class Recipe extends React.Component<IRecipeProps, {}> {
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