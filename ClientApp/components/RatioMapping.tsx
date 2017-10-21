import * as React from "react";

interface IRatioMappingProps {
    decimal: number
  }

export class RatioMapping extends React.Component<IRatioMappingProps, {}> {
    public render() { 
        let { decimal } = this.props;
        switch(decimal) {
            case 0.2:
                return <span>1/5</span>;
            case 0.25:
                return <span>1/4</span>;
            case 0.33:
                return <span>1/3</span>;
            case 0.4:
                return <span>2/5</span>;
            case 0.5:
                return <span>1/2</span>;
            case 0.6:
                return <span>3/5</span>;
            case 0.66: 
                return <span>2/3</span>;
            case 0.75:
                return <span>3/4</span>;
            case 0.8:
                return <span>4/5</span>;
            default:
                return <span>{`${decimal}`}</span>;
        }
    }
}