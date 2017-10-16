import * as React from "react";
import { ITag, IIngredient, IRecipe, IRecipeProps } from "../models/index";

export class Recipe extends React.Component<IRecipeProps, {}> {
  public render() {
    let {
      description,
      drinkware,
      garnishes,
      imageUrl,
      ingredients,
      name,
      photoCred,
      preparation,
      service,
      tags
    } = this.props.recipe;

    return (
      <div className="container">
        <h2>{name}</h2>
        <div className="row">
          <div className="col s6">
            <h4>Description</h4>
            <div className="description">{description}</div>
            <h4>Ingredients</h4>
            <ul className="ingredients">
              {ingredients.map((ingredient, index) => {
                return (
                  <li key={`${ingredient.ingredientName}` + index}>
                    {ingredient.amount} {ingredient.measurement}{" "}
                    {ingredient.ingredientName}
                  </li>
                );
              })}
            </ul>
            <h4>Directions: </h4>
            <div className="directions">{preparation}</div>
            {drinkware && <div>Glass: {drinkware}</div>}
            {service && <div>Serve: {service}</div>}
            {garnishes && (
              <div>
                Garnish:{" "}
                {garnishes.map((g, index) => {
                  return <span key={`${g} ${index}`}>{g.ingredientName}</span>;
                })}
              </div>
            )}
            {tags && (
              <div>
                Tags:{" "}
                {tags
                  .map(t => {
                    return t.name;
                  })
                  .join(", ")}
              </div>
            )}
          </div>
          <div className="col s6">
            <img src={imageUrl} className="cocktail-image" />
            <h5>
              <em>Photo Credit: {photoCred}</em>
            </h5>
          </div>
        </div>
      </div>
    );
  }
}
